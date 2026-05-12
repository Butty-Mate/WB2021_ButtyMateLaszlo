import { createRouter, createWebHistory } from 'vue-router';
import Openpage from './pages/Openpage.vue';
import Offers from './pages/Offers.vue';
import Newadd from './pages/Newadd.vue';


const routes = [
    {
        path: '/',
        name: 'Openpage',
        component: Openpage,
    },
    {
        path: '/offers',
        name: 'Offers',
        component: Offers,
    },
    {
        path: '/newadd',
        name: 'Newadd',
        component: Newadd,
    },

    
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
