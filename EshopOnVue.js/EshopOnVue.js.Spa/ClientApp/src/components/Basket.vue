<template>
    <div @click="expandItems = !expandItems;" style="margin: 5px; background-color: lightgray;">Items</div>
    <v-expand-transition>
        <v-card v-show="expandItems" class="mx-auto" style="background-color:floralwhite;">
            <section class="esh-catalog-filters">
                <div class="container">
                    <p v-if="basketItems.length == 0"><em>Empty basket</em></p>
                    <div class="esh-catalog-items row">
                        <BasketItem @remove-item="removeItem" @update-quantity="updateQuantity" :basketItem="basketItem"
                            v-for="basketItem of basketItems" v-bind:key="basketItem" />
                    </div>
                    <v-btn v-if="basketItems.length > 0" @click="step2">Next</v-btn>
                </div>
            </section>
        </v-card>
    </v-expand-transition>
    <div v-if="basketItems.length > 0" @click="expandPersonnalInformation = !expandPersonnalInformation;"
        style=" margin: 5px; background-color: floralwhite;">
        Personal info
    </div>
    <v-expand-transition v-if="basketItems.length > 0">
        <v-card v-show="expandPersonnalInformation" class="mx-auto" style="background-color: beige;">

            <v-form v-model="valid" ref="form">
                <v-container>
                    <v-row>
                        <v-col cols="12" md="4">
                            <v-text-field v-model="firstname" label="First name" :rules="firstnameRules"></v-text-field>
                        </v-col>

                        <v-col cols="12" md="4">
                            <v-text-field v-model="lastname" label="Last name" :rules="nameRules"></v-text-field>
                        </v-col>

                        <v-col cols="12" md="4">
                            <v-text-field type="mail" v-model="mail" label="E-mail" :rules="emailRules"></v-text-field>
                        </v-col>
                    </v-row>
                </v-container>
            </v-form>
            <v-btn v-if="basketItems.length > 0" @click="step3">Validate</v-btn>
        </v-card>
    </v-expand-transition>
    <div v-if="orderValidate" @click="expandPayment = !expandPayment;" style=" margin: 5px; background-color: lightgray;">
        Payment</div>
    <v-expand-transition v-if="orderValidate">
        <v-card class="mx-auto" style="background-color: floralwhite;">
            Payment detail
        </v-card>
    </v-expand-transition>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import BasketItem from "./BasketItem.vue";

import BasketItemData from "../types/basketItemData";
import { VForm } from "vuetify/lib/components/index.mjs";

@Options({
    components: {
        BasketItem
    },
    data() {
        return {
            mail: '',
            firstname: '',
            lastname: '',
        }
    }
})
export default class Basket extends Vue {
    expandItems = true;
    expandPersonnalInformation = false;
    expandPayment = false;
    basketItems: BasketItemData[] = [];
    orderValidate = false;
    mail: string | undefined;
    valid = false;
    firstname = '';
    lastname = '';

    nameRules = [
        (v: any) => !!v || 'Name is required',
        (v: any) => (v && v.length >= 3) || 'Name must be more than 3 characters',
    ];
    firstnameRules = [
        (v: any) => !!v || 'FirstName is required',
        (v: any) => (v && v.length >= 3) || 'FirstName must be more than 3 characters',
    ];
    emailRules = [
        (v: any) => !!v || 'E-mail is required',
        (v: any) => /.+@.+\..+/.test(v) || 'E-mail must be valid',
    ];

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
    step2(): void {
        this.expandItems = false;
        this.expandPersonnalInformation = true;
    }
    async step3(): Promise<void> {
        const form = this.$refs.form as VForm
        const result = await form.validate();
        if (result.valid) {
            this.expandItems = false;
            this.expandPersonnalInformation = false;
            this.expandPayment = true;
            this.orderValidate = true;
            this.basketItems = [];
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
