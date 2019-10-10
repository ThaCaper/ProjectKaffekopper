<template>
    <div>
        <h1>CREATE NEW CUP TO OUR SHOP</h1>
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <body>

        <form class="w3-container w3-card-4" action="">
            <h2 class="w3-text-black">Input data under</h2>
            <p>Fill the text fields with the correct data</p>
            <p>
                <label class="w3-text-black"><b>Name</b></label>
                <v-text-field
                        v-model="name"
                        label="Name of the new product"
                        required
                ></v-text-field>
            <p>
                <label class="w3-text-black"><b>Color</b></label>
                <v-select
                        v-model="color"
                        :items="colors"
                        label="Standard"
                ></v-select>
            <p>
                <label class="w3-text-black"><b>Volume(cl)</b></label>
            <v-text-field
                    v-model="volume"
                    label="The volume cl"
                    required
            ></v-text-field>
            <p>
                <label class="w3-text-black"><b>Material</b></label>
            <v-select
                    v-model="material"
                    :items="materials"
                    label="Standard"
            ></v-select>
            <p>
                <label class="w3-text-black"><b>Description</b></label>
            <v-text-field
                    v-model="description"
                    label="The products description"
                    required
            ></v-text-field>
            <p>
                <label class="w3-text-black"><b>Price</b></label>
            <v-text-field
                    v-model="price"
                    label="The price of the product"
                    required
            ></v-text-field>
            <p>

            <button class="w3-btn w3-blue"  @click="createCoffeeCup">Register</button></p>
        </form>

        </body>

    </div>
</template>
¨
<script>
    import axios from 'axios';
    export default {
        mounted() {
            this.createCoffeeCup()
        },
        data () {
            return {
            coffeeCups: [],
                name: '',
                color:'Blue',
                colors: ['Yellow', 'Red', 'Black', 'White', 'Silver', 'Green', 'Blue', 'Orange' ],
                volume: '',
                material: 'Cardboard',
                materials: ['Plastic', 'Cardboard', 'Aluminum', 'Steel', 'Ceramic'],
                description: '',
                price: '00,00'
        }},
        methods: {
            createCoffeeCup() {
                axios.post('http://coffeecupshop.azurewebsites.net/api/coffeeCups', {
                    name: this.name,
                    color: this.color,
                    volume: +this.volume,
                    material: this.material,
                    description: this.description,
                    price: +this.price
                }).then(() => {
                    this.$router.push({ path: '/coffeeCupList' })
                });
            }
        }
    };
</script>
