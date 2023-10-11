import { createWebHistory, createRouter } from "vue-router";
import Home from "@/components/Home.vue";
import CatalogDetail from "@/components/CatalogDetail.vue";
import Counter from "@/components/Counter.vue";
import FetchData from "@/components/FetchData.vue";

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
    },
    {
        path: "/CatalogDetail/:CatalogItemId",
        name: "CatalogDetail",
        component: CatalogDetail,
    },
    {
        path: "/Counter",
        name: "Counter",
        component: Counter,
    },
    {
        path: "/FetchData",
        name: "FetchData",
        component: FetchData,
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;