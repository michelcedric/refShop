<template>
    <section class="esh-catalog-filters">
        <div class="container">
            <p v-if="!catalogItem"><em>Loading...</em></p>
            <img class="esh-catalog-thumbnail" :src="'/' + catalogItem.pictureUri" />
            <div class="esh-catalog-name">
                <span>{{ catalogItem.name }}</span>
            </div>
            <div class="esh-catalog-price">
                <span>{{ formatPrice(catalogItem.price) }}</span>
            </div>
            <div class="esh-catalog-price">
                <span>{{ formatPrice(catalogItem.memberPrice) }}</span>
            </div>
            <div class="esh-catalog-price">
                <select v-model="selected">
                    <option v-for="option in catalogItem.sizes" :value="option.id">
                        {{ option.description }}
                    </option>
                </select>
            </div>
        </div>
    </section>
</template>

<script>
import CatalogDetail from "./CatalogDetail";
import axios from 'axios';
export default {
    name: "CatalogDetail",
    components: {
        CatalogDetail
    },
    data() {
        return {
            catalogItem: Object
        }
    },
    methods: {
        getCatalogItem() {

            axios.get('/api/catalog/' + this.$route.params.CatalogItemId)
                .then((response) => {
                    this.catalogItem = response.data;
                })
                .catch(function (error) {
                    alert(error);
                });
        },
        formatPrice(value) {
            let val = (value / 1).toFixed(2).replace('.', ',')
            return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
        }
    },
    mounted() {
        this.getCatalogItem();
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
