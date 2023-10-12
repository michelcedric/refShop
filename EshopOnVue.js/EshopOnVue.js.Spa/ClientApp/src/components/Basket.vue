<template>
    <section class="esh-catalog-filters">
        <div class="container">
            <p v-if="basketItems.length == 0"><em>Empty basket</em></p>
            <div class="esh-catalog-items row">
                <BasketItem @remove-item="removeItem" @update-quantity="updateQuantity" :basketItem="basketItem"
                    v-for="basketItem of basketItems" v-bind:key="basketItem" />
            </div>
        </div>
    </section>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import BasketItem from "./BasketItem.vue";

import BasketItemData from "../types/basketItemData";

@Options({
    components: {
        BasketItem
    }
})
export default class Basket extends Vue {

    basketItems: BasketItemData[] = [];

    mounted(): void {
        this.getBasketItems();
    }
    getBasketItems() {
        const existingBasket = localStorage.getItem("refShopBasket");
        if (existingBasket) {
            this.basketItems = JSON.parse(existingBasket) as BasketItemData[]
        }
    }
    removeItem(id: string) {
        this.basketItems = this.basketItems.filter(i => i.id != id);
        localStorage.setItem("refShopBasket", JSON.stringify(this.basketItems));
    }

    updateQuantity(id: string, quantity: number) {
        const item = this.basketItems.find(i => i.id == id);
        if (item) {
            item.quantity = quantity;          
            localStorage.setItem("refShopBasket", JSON.stringify(this.basketItems));
        }
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
