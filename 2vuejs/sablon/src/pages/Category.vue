<template>
    <div class="container">
        <h1 class="text-center">Lista kategória szűrve</h1>
        <p>GET kérés küldése a <code>/api/Kategoriak/{id}</code> végpontra</p>
        <p>A táblázatban megjelenik a módosítás és a törlés gomb is.</p>
        
        <label for="category">Túra kategóriája:</label>     
        <select class="form-select" v-model="selectedCategory" @change="lekerdezTurakCategory">
            <option value="0">-- Válassz ketegóriát --</option>
            <option v-for="kategoria in kategoriak" :key="kategoria.id" :value="kategoria.id">{{ kategoria.ikon }} {{ kategoria.nev }}</option>
        </select>

        <table v-if="turak.length > 0" class="table table-striped mt-3">
            <tr>
                <th>ID</th>
                <th>Név</th>
                <th>Távolság</th>
                <th>Nehézség</th>
                <th>Idő</th>
                <th>Helyszin</th>
                <th>Műveletek</th>
            </tr>
            <tr v-for="tura in turak" :key="tura.id">
                <td>{{ tura.id }}</td>
                <td>{{ tura.nev }}</td>
                <td>{{ tura.tavolsagKm }} km</td>
                <td>{{ tura.nehezseg }}</td>
                <td>{{ tura.becsultIdoPerc }} perc</td>
                <td>{{ tura.helyszin }}</td>
                <td>
                    <button class="btn btn-warning" @click="modositTura(tura.id)">Módosít</button>
                    <button class="btn btn-danger" @click="torolTura(tura.id)">Töröl</button>
                </td>

            </tr>
        </table>
    </div>
</template>

<script>
import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:5000/api';

export default {
    name: 'Category',
    data() {
        return {
            kategoriak: [],
            selectedCategory: 0,
            turak: []
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
            if (this.selectedCategory) {
                axios.get(`/Kategoriak/${this.selectedCategory}`)
                    .then(response => {
                        this.turak = response.data.turak;
                    })
                    .catch(error => {
                        console.error('Hiba a kategóriához tartozó turák lekérésekor:', error);
                    });
            } else {
                this.turak = [];
            }
        },
        modositTura(id) {
            this.$router.push({ name: 'Update', params: { id } });
        },
        torolTura(id) {
            if (confirm('Biztosan törölni szeretnéd ezt a túrát?')) {
                axios.delete(`/Turak/${id}`)
                    .then(() => {
                        this.lekerdezTurakCategory();
                    })
                    .catch(error => {
                        console.error('Hiba a túra törlésekor:', error);
                    });
            }
        }

}}

</script>