<template>
    <section class="esh-catalog-hero">
        <div class="container">
            <img class="esh-catalog-title" src="../assets/main_banner_text.png" />
        </div>
    </section>
    <section class="esh-catalog-filters">
        <div class="container">
            <p v-if="!catalogItems"><em>Loading...</em></p>
            <div class="esh-catalog-items row">
                <CatalogItem :catalogItem="catalogItem" v-for="catalogItem of catalogItems" v-bind:key="catalogItem" />
            </div>
        </div>
    </section>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import CatalogItem from "./CatalogItem.vue";
import CatalogItemData from "../types/CatalogItemData"
import axios from 'axios';

@Options({
    data() {
        return { a: 1 }
    },
    components: {
        CatalogItem
    },
})
export default class Home extends Vue {

    catalogItems: CatalogItemData[] = [];

    mounted(): void {
        this.getCatalogItems();
    }
    getCatalogItems() {
        axios.get<CatalogItemData[]>('/api/catalog')
            .then((response) => {
                this.catalogItems = response.data;
            })
            .catch(function (error) {
                alert(error);
            });
    }
};
</script>

<style scoped>
.esh-catalog-title {
    position: relative;
    top: 74.28571px;
}

.esh-catalog-items {
    margin-top: 1rem;
}

.esh-catalog-item {
    margin-bottom: 1.5rem;
    text-align: center;
    width: 33%;
    display: inline-block;
    float: none !important;
}

@media screen and (max-width: 1024px) {
    .esh-catalog-item {
        width: 50%;
    }
}

@media screen and (max-width: 768px) {
    .esh-catalog-item {
        width: 100%;
    }
}

.esh-catalog-hero {
    background-image: url("../assets/main_banner.png");
    background-size: cover;
    height: 260px;
    width: 100%;
}

.esh-catalog-filter {
    -webkit-appearance: none;
    background-color: transparent;
    border-color: #00d9cc;
    color: #FFFFFF;
    cursor: pointer;
    margin-right: 1rem;
    margin-top: .5rem;
    min-width: 140px;
    outline-color: #83D01B;
    padding-bottom: 0;
    padding-left: 0.5rem;
    padding-right: 0.5rem;
    padding-top: 1.5rem;
}

.esh-catalog-filter option {
    background-color: #00A69C;
}
</style>
