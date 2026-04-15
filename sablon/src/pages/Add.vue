<template>
<div class="container">
    <h1 class="text-center">Túra hozzáadása</h1>
    <p>POST kérés küldése a <code>api/Turak</code> végpontra</p>

<form action="">
    <div class="mb-3">
        <label for="nev" class="form-label">Név:</label>
        <input type="text" class="form-control" id="nev" v-model="tura.nev">
    </div>
    <div class="mb-3">
        <label for="kategoria" class="form-label">Túra Kategóriák:</label>
        <select class="form-select" v-model="selectedCategory" @change="lekerdezTurakCategory">
            <option value="0">-- Válassz ketegóriát --</option>
            <option v-for="kategoria in kategoriak" :key="kategoria.id" :value="kategoria.id">{{ kategoria.ikon }} {{ kategoria.nev }}</option>
        </select>

    </div>
    <div class="mb-3">
        <label for="tavolsagKm" class="form-label">Távolság:</label>
        <input type="number" class="form-control" id="tavolsagKm" v-model="tura.tavolsagKm ">   
    </div>
    <div class="mb-3">  
        <label for="nehezseg" class="form-label">Nehézség:</label>
        <input type="text" class="form-control" id="nehezseg" v-model="tura.nehezseg">
    </div>
    <div class="mb3">
        <label for="szintkulonbsegM" class="form-label">Szintkülönbség (m):</label>
        <input type="number" class="form-control" id="szintkulonbsegM" v-model="tura.szintkulonbsegM">
    </div>
    <div class="mb-3">
        <label for="becsultIdoPerc" class="form-label">Becsült idő (perc):</label>
        <input type="number" class="form-control" id="becsultIdoPerc" v-model="tura.becsultIdoPerc">
    </div>
    <div class="mb-3">
        <label for="helyszin" class="form-label">Helyszín</label>
        <input type="text" class="form-control" id="helyszin" v-model="tura.helyszin">
    </div>
    <div class="mb3">
        <label for="leiras" class="form-label">Leírás:</label>
        <textarea class="form-control" id="leiras" v-model="tura.leiras"></textarea>
    </div>
    <div class="mb3">
        <label for="kutyaBarat" class="form-label">Kutyabarát:</label>
        <input type="checkbox" class="form-check-input" id="kutyaBarat" v-model="tura.kutyaBarát">

    </div>
    <button type="submit" class="btn btn-primary" @click.prevent="addTura">Hozzáadás</button>


</form>
</div>
</template>
<script>
import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:5000/api';

export default {
    name: 'Add',
    data() {
        return {
            kategoriak: [],
            selectedCategory: 0,
            tura: {
                nev: '',
                kategoriaId: 0,
                tavolsagKm: 0,
                nehezseg: '',
                szintkulonbsegM: 0,
                becsultIdoPerc: 0,
                helyszin: '',
                leiras: '',
                kutyaBarát: false
            }
        }
    },
    mounted() {
        axios.get('/Kategoriak')
            .then(response => {
                this.kategoriak = response.data;
            })
            .catch(error => {
                console.error('Hiba a kategóriák lekérésekor:', error);
            });
    },
    methods: {
        lekerdezTurakCategory() {
            this.tura.kategoriaId = this.selectedCategory;
        },
        addTura() {
            axios.post('/Turak', this.tura)
                .then(() => {
                    alert('Túra sikeresen hozzáadva!');
                    this.$router.push('/category');
                })
                .catch(error => {
                    console.error('Hiba a túra hozzáadásakor:', error);
                    alert('Hiba történt a túra hozzáadásakor. Kérem, próbálja újra!');
                });
        }
    }
}
</script>