#WinForms
## 1. Fájl beolvasás – `OpenFileDialog` + `File.ReadAllLines`

```csharp
using System.IO;  // EZT NE FELEJTSD EL FELÜL!

OpenFileDialog ofd = new OpenFileDialog();
ofd.Filter = "Szövegfájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*";

if (ofd.ShowDialog() == DialogResult.OK)
{
    string[] sorok = File.ReadAllLines(ofd.FileName);
    // sorok[0], sorok[1], ... minden sor egy elem
}
```

## 2. Sor feldarabolása (split pontosvesszővel)

```csharp
// Ha a fájl soronként: név;ár1;ár2
string[] reszek = sorok[i].Split(';');
string nev   = reszek[0];
int ar1      = int.Parse(reszek[1]);
int ar2      = int.Parse(reszek[2]);
```

## 3. Vezérlők tömbbe rakása (hogy for ciklussal lehessen kezelni)

Ha van pl. `chk0, chk1, chk2` stb., akkor tömbbe rakod:

```csharp
CheckBox[] checkBoxok = new CheckBox[] { chk0, chk1, chk2, chk3, chk4 };
RadioButton[] rbA = new RadioButton[] { rbA0, rbA1, rbA2, rbA3, rbA4 };
RadioButton[] rbB = new RadioButton[] { rbB0, rbB1, rbB2, rbB3, rbB4 };
TextBox[] txtMezok = new TextBox[] { txt0, txt1, txt2, txt3, txt4 };
```

Utána for ciklussal mész végig:

```csharp
for (int i = 0; i < db; i++)
{
    checkBoxok[i].Text = nevek[i];
    rbA[i].Text = arak1[i].ToString();
    rbB[i].Text = arak2[i].ToString();
}
```

## 4. RadioButton csoportosítás – `Panel`-lel

Ha több sorban van RadioButton, és azt akarod hogy **soronként függetlenül** lehessen választani:
- Minden sorhoz kell egy **külön Panel**
- A 2 RadioButton belekerül a Panel-be
- Így soronként csak az egyiket lehet kiválasztani

```csharp
// Designer-ben:
panelRadio0.Controls.Add(rbA0);
panelRadio0.Controls.Add(rbB0);

panelRadio1.Controls.Add(rbA1);
panelRadio1.Controls.Add(rbB1);
// ... stb.
```

> ⚠️ **FONTOS**: Ha az összes RadioButton ugyanazon a Form-on / Panel-en van,
> akkor az egész form-on csak 1-et lehet kiválasztani! Ezért kell soronként külön Panel!

## 5. Vezérlők láthatósága (nézetek váltása)

```csharp
// Elrejtés
panel.Visible = false;
gomb.Visible = false;

// Megjelenítés
panel.Visible = true;
gomb.Visible = true;
```

Tipp: Rakd az összes "második nézet" vezérlőt egy **Panel**-be, és csak a panelt kell ki/be kapcsolni.

## 6. Validálás (ellenőrzés a számolás előtt)

### a) Van-e kijelölt elem?

```csharp
bool vanKivalasztva = false;
for (int i = 0; i < db; i++)
{
    if (checkBoxok[i].Checked)
    {
        vanKivalasztva = true;
        break;
    }
}
if (!vanKivalasztva)
{
    MessageBox.Show("Válassz legalább egyet!", "Hiba",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}
```

### b) Ki van-e választva RadioButton?

```csharp
if (!rbA[i].Checked && !rbB[i].Checked)
{
    MessageBox.Show("Válassz opciót!", "Hiba",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}
```

### c) Pozitív egész szám ellenőrzés (`int.TryParse`)

```csharp
int szam;
if (!int.TryParse(textBox.Text.Trim(), out szam) || szam <= 0)
{
    MessageBox.Show("Adj meg pozitív egész számot!", "Hiba",
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
}
```

## 7. Összeg számolás

```csharp
int osszeg = 0;
for (int i = 0; i < db; i++)
{
    if (!checkBoxok[i].Checked)
        continue;  // ha nincs kipipálva, ugorjuk át

    int ar = rbA[i].Checked ? arak1[i] : arak2[i];  // melyik opció
    int darab = int.Parse(txtMezok[i].Text);
    osszeg += ar * darab;
}
txtEredmeny.Text = osszeg.ToString() + " Ft";
```

## 8. Törlés (reset)

```csharp
for (int i = 0; i < db; i++)
{
    checkBoxok[i].Checked = false;
    rbA[i].Checked = false;
    rbB[i].Checked = false;
    txtMezok[i].Text = "";
}
txtEredmeny.Text = "";
```

## 9. Csak olvasható TextBox

```csharp
txtEredmeny.ReadOnly = true;
```

## 10. Hasznos tulajdonságok Designerben

| Mit akarok?                     | Tulajdonság / kód                                    |
|---------------------------------|------------------------------------------------------|
| Gomb felirata                   | `button.Text = "Szöveg";`                            |
| Háttérszín                      | `this.BackColor = Color.Beige;`                      |
| Félkövér piros label            | `label.Font = new Font(..., FontStyle.Bold);`        |
|                                 | `label.ForeColor = Color.Red;`                       |
| Vezérlő elrejtése               | `control.Visible = false;`                           |
| Gomb letiltása                  | `button.Enabled = false;`                            |

---

## 🔑 Lényeg összefoglalva

1. **`File.ReadAllLines`** + **`Split(';')`** → fájlból adatok kinyerése
2. **Vezérlő tömbök** (`CheckBox[]`, `RadioButton[]`, `TextBox[]`) → for ciklussal kezelés
3. **Panel** → RadioButton csoportosítás soronként
4. **Panel.Visible** → nézetek közötti váltás (induló ↔ adatbeviteli)
5. **`int.TryParse`** → biztonságos szám ellenőrzés
6. **`continue`** → kihagyás a ciklusban ha nincs kipipálva
7. **Ternary operátor** (`? :`) → melyik ár kell (opció A vagy B)
