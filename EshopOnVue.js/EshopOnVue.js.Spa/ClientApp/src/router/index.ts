import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import Basket from "@/components/Basket.vue";
import CatalogDetail from "@/components/CatalogDetail.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },    
    {
        path: "/basket",
        name: "Basket",
        component: Basket,
    },    {
        path: "/CatalogDetail/:CatalogItemId",
        name: "CatalogDetail",
        component: CatalogDetail,
    },    
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;