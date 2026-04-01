<template>
    <div class="container">
        <h1 class="text-center">Lista</h1>
        <p>GET kérés küldése a <code>/api/Turak</code> végpontra.</p>
        <table>
            <tr>
                <th>ID</th>
                <th>Név</th>
                <th>Kategória</th>
                <th>Távolság</th>
                <th>Nehézség</th>
                <th>Szint</th>
                <th>idő</th>
                <th>Helyszín</th>
                <th>Leírás</th>
                <th>Kutyabarát</th>
            </tr>
            <tr v-for="tura in turak" :key="tura.id">
                <td>{{ tura.id }}</td>
                <td>{{ tura.nev }}</td>
                <td>{{ tura.kategoria.ikon }} {{ tura.kategoria.nev }}</td>
                <td>{{ tura.tavolsagKm }} km</td>
                <td>{{ tura.nehezseg }}</td>
                <td>{{ tura.szintkulonbsegM }} méter</td>
                <td>{{ tura.becsultIdoPerc }} perc</td>
                <td>{{ tura.helyszin }}</td>
                <td>{{ tura.leiras }}</td>
                <td class="text-center" :class="tura.kutyaBarát ? 'zold' : 'piros'">{{ tura.kutyaBarát ? 'Igen' : 'Nem' }}</td  >
            </tr>
        </table>
    </div>
</template>

<script>
import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:5000/api';

export default {
    name: 'List',
    data() {
        return {
            turak: []
        }
    },
    mounted() {
        axios.get('/Turak')
            .then(response => {
                this.turak = response.data;
            })
            .catch(error => {
                console.error('Hiba a turák lekérésekor:', error);
            }); 
    },

}

</script>

<style>
    table {
        width: 100%;
        border-collapse: collapse;
        margin: 20px auto;
        box-shadow: 5px 5px 15px rgba(0,0,0,0.3);   
    }

    table th, table td {
        border: 1px solid #ddd;
        padding: 8px;
        text-align: left;
    }

    th {
        text-align: center;
    }

    .zold{
        color: green;
    }
    .piros{
        color: red;
    }
</style>
