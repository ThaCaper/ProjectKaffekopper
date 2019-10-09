<template>
    <div>
        <h1>Coffee Cups</h1>
        <ul>
            <li v-for="product in coffeeCups"
                v-bind:key="product.id">{{product}}</li>
        </ul>

    </div>
</template>
¨
<script>
    import axios from 'axios';
    export default {
        mounted() {
            this.fetchProducts()
        },
        data: ()  => ({
            coffeeCups: []
        }),
        methods: {
            fetchProducts() {
                axios.get('')
                    .then((data) => {
                        this.coffeeCups = data.data.list;
                    });
            }
        }
    };
</script>