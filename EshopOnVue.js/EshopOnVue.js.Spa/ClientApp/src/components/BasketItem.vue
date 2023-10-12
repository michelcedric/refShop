<template>
    <div class="esh-catalog-item col-md-4">
        <div class="esh-catalog-name">

            <img class="esh-catalog-thumbnail" :src="basketItem.catalogItem.pictureUri" />
            <div class="esh-catalog-name">
                <span>{{ basketItem.catalogItem.name }}</span>
            </div>
            <div class="esh-catalog-name">
                <span>{{ basketItem.size?.description }}</span>
            </div>
            <div class="esh-catalog-name">
                <input min="1" type="number" v-model="basketItem.quantity"
                    @change="updateQuantity(basketItem.id, basketItem.quantity)" />
            </div>
            <div class="esh-catalog-price">
                <span>{{ formatPrice(basketItem.catalogItem.price) }}</span>
            </div>
            <div class="esh-catalog-name">
                <span> <button @click="removeBasketItem(basketItem.id)">Remove</button></span>
            </div>

        </div>
    </div>
</template>

<script lang="ts">
import BasketItemData from "../types/basketItemData"
import { Vue, prop } from "vue-class-component";

export class Props {
    basketItem = prop<BasketItemData>({ required: true });
}

export default class CatalogItem extends Vue.with(Props) {
    removeBasketItem(id: string): void {
        this.$emit('remove-item', id)
    }
    updateQuantity(id: string, quantity: number): void {
        this.$emit('update-quantity', id, quantity)
    }
    formatPrice(value: number) {
        let val = (value / 1).toFixed(2).replace('.', ',')
        return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
    }
}
</script>

<style scoped>
.esh-catalog-price {
    font-size: 28px;
    font-weight: 900;
    text-align: center;
}

.esh-catalog-price::after {
    content: '\20AC';
}

.esh-catalog-name {
    font-size: 1rem;
    font-weight: 300;
    margin-top: .5rem;
    text-align: center;
    text-transform: uppercase;
}

.esh-catalog-thumbnail {
    max-width: 370px;
    width: 100%;
}

.esh-catalog-button {
    background-color: #83D01B;
    border: 0;
    color: #FFFFFF;
    cursor: pointer;
    font-size: 1rem;
    height: 3rem;
    margin-top: 1rem;
    transition: all 0.35s;
    width: 80%;
}

.esh-catalog-button.is-disabled {
    opacity: .5;
    pointer-events: none;
}

.esh-catalog-button:hover {
    background-color: #4a760f;
    transition: all 0.35s;
}
</style>