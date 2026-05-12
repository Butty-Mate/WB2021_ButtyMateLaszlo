<template>
    <div class="container">
        <h1 class="text-center">Lista nehezseg szerint</h1>
        <p>GET kerest kuld a <code>/api/Turak</code> vegpontra, majd szuri a listat.</p>

        <label for="difficulty">Nehezseg:</label>
        <select id="difficulty" class="form-select" v-model="selectedDifficulty">
            <option value="">-- Osszes nehezseg --</option>
            <option v-for="level in difficultyOptions" :key="level" :value="level">
                {{ level }}
            </option>
        </select>

        <table v-if="filteredTurak.length > 0" class="table table-striped mt-3">
            <tr>
                <th>ID</th>
                <th>Nev</th>
                <th>Kategoria</th>
                <th>Tavolsag</th>
                <th>Nehezseg</th>
                <th>Ido</th>
                <th>Helyszin</th>
            </tr>
            <tr v-for="tura in filteredTurak" :key="tura.id">
                <td>{{ tura.id }}</td>
                <td>{{ tura.nev }}</td>
                <td>{{ tura.kategoria.ikon }} {{ tura.kategoria.nev }}</td>
                <td>{{ tura.tavolsagKm }} km</td>
                <td>{{ tura.nehezseg }}</td>
                <td>{{ tura.becsultIdoPerc }} perc</td>
                <td>{{ tura.helyszin }}</td>
            </tr>
        </table>

        <p v-else class="mt-3">Nincs megjelenitheto tura.</p>
    </div>
</template>

<script>
import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:5000/api';

export default {
    name: 'Filter',
    data() {
        return {
            turak: [],
            selectedDifficulty: ''
        };
    },
    computed: {
        difficultyOptions() {
            const levels = this.turak
                .map(tura => tura.nehezseg)
                .filter(level => level && level.trim() !== '');

            return [...new Set(levels)].sort();
        },
        filteredTurak() {
            if (!this.selectedDifficulty) {
                return this.turak;
            }
            return this.turak.filter(
                tura => tura.nehezseg === this.selectedDifficulty
            );
        }
    },
    mounted() {
        axios.get('/Turak')
            .then(response => {
                this.turak = response.data;
            })
            .catch(error => {
                console.error('Hiba a turak lekeresekor:', error);
            });
    }
};
</script>
