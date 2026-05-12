
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap'
import router from './router'
import axios from 'axios'
import './assets/style.css'

import { createApp } from 'vue'
import App from './App.vue'
import Openpage from './pages/Openpage.vue';
import Offers from './pages/Offers.vue';
import Newadd from './pages/Newadd.vue';

createApp(App)
    .component('Openpage', Openpage)
    .component('Offers', Offers)
    .component('Newadd', Newadd)
    .use(router)
    .use(axios)
    .mount('#app')