<template>
    <div>
        <h1>Coffee Cups list</h1>

          <table >
              <tr>
                  <th>Id</th>
                  <th>Name</th>
                  <th>Description</th>
                  <th>Color</th>
                  <th>Material</th>
                  <th>Volume</th>
                  <th>Price</th>
                  <th>Update</th>
                  <th>Delete</th>
              </tr>
              <tr v-for="product in coffeeCups"
                  v-bind:key="product.id">
                  <td>{{product.id}}</td>
                  <td>{{product.name}}</td>
                  <td>{{product.description}}</td>
                  <td>{{product.color}}</td>
                  <td>{{product.material}}</td>
                  <td>{{product.volume}} cl</td>
                  <td>{{product.price}}</td>
                  <td><router-link :to="{path:'/coffeeCupUpdate/' + product.id}"><v-btn>Update</v-btn></router-link></td>
                  <td><v-btn @click="deleteButton(product.id)">Delete</v-btn></td>
            </tr>
          </table>


    </div>
</template>
¨
<script>
    import axios from 'axios';
    export default {
        mounted() {
            this.fetchProducts()
        },
        data () {
        return {
            coffeeCups: []

        }},
        methods: {
            fetchProducts() {

                axios.get('http://coffeecupshop.azurewebsites.net/api/coffeeCups')
                    .then((data) => {
                        this.coffeeCups = data.data})
            },
            deleteButton(id)
            {
                axios.delete('http://coffeecupshop.azurewebsites.net/api/coffeeCups/' + id)
                    .then(() => {
                        this.fetchProducts()})
            }
        }};
</script>
<style>
    table {
        font-family: "Fira Sans", sans-serif, Helvetica;
        border-collapse: collapse;
        width: 100%;
    }

    table td, table th {
        border: 1px solid #ddd;
        padding: 8px;
    }

    table tr:nth-child(even){background-color: #f2f2f2;}

    table tr:hover {background-color: #ddd;}

    table th  {
        padding-top: 10px;
        padding-bottom: 10px;
        text-align: center;
        background-color: #ff9218;
        color: white;
    }
</style>