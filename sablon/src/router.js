import { createRouter, createWebHistory } from 'vue-router';
import Home from './pages/Home.vue';
import List from './pages/List.vue';
import Category from './pages/Category.vue';

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home,
    },
    {
        path: '/list',
        name: 'List',
        component: List,
    },
        {
        path: '/category',
        name: 'Category',
        component: Category,
    }
    
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
