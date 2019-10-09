<template>
  <div id="app">
    <div id="nav">
      <router-link to="/coffeeCupCreate">Create</router-link> |
      <router-link to="/coffeeCupList">Read</router-link> |
      <router-link to="/coffeeCupDelete/">Delete</router-link>
    </div>
    <router-view/>
  </div>
</template>

<script>
  import axios from 'axios';
export default {
  name: 'App',
  components: {},
  data: () => ({
    //
  }),
};
</script>

<style>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
</style>
