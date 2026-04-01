<template>
    <form action="">
    <div class="mb-3">
        <label for="nev" class="form-label"></label>
        <input type="text" class="form-control" id="nev" v-model="tura.nev">
    </div>
    <div class="mb-3">
        <label for="tavolsag" class="form-label"></label>
        <input type="number" class="form-control" id="tavolsag" v-model="tura.tavolsag">
    </div>
    <div class="mb-3">
        <label for="nehezseg" class="form-label"></label>
        <input type="text" class="form-control" id="nehezseg" v-model="tura.nehezseg">
    </div>
    <div class="mb-3">
        <label for="becsultIdoPerc" class="form-label"></label>
        <input type="number" class="form-control" id="becsultIdoPerc" v-model="tura.becsultIdoPerc">
    </div>
    <div class="mb-3">
        <label for="helyszin" class="form-label"></label>
        <input type="text" class="form-control" id="helyszin" v-model="tura.helyszin">
    </div>
    <button type="submit" class="btn btn-primary" @click.prevent="updateTura">Módosítás</button>
    </form>
</template>

<script>
import axios from 'axios';
axios.defaults.baseURL = 'http://localhost:5000/api';

export default {
    name: 'Update',
    data() {
        return {
            tura: {
                nev: '',
                tavolsag: 0,
                nehezseg: '',
                becsultIdoPerc: 0,
                helyszin: ''
            }
        }
    },
    mounted() {
        const id = this.$route.params.id;
        axios.get(`/Turak/${id}`)
            .then(response => {
                this.tura = response.data;
            })
            .catch(error => {
                console.error('Hiba a túra lekérésekor:', error);
            });
    }
}
</script>