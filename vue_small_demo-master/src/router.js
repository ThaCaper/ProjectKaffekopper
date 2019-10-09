import Vue from 'vue'
import Router from 'vue-router'
import CoffeeCupList from "./views/CoffeeCups/CoffeeCupList";
import CoffeeCupCreate from "./views/CoffeeCups/CoffeeCupCreate";
import CoffeeCupUpdate from "./views/CoffeeCups/CoffeeCupUpdate";
import CoffeeCupDelete from "./views/CoffeeCups/CoffeeCupDelete";

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/coffeeCupCreate',
      name: 'Create-Cups',
      component: CoffeeCupCreate
    },
    {
      path: '/coffeeCupList',
      name: 'Coffee-Cups',
      component: CoffeeCupList
    },
    {
      path: '/coffeeCupUpdate/:id',
      name: 'Update-Cups',
      component: CoffeeCupUpdate
    },
    {
      path: '/coffeeCupDelete',
      name: 'Delete-Cups',
      component: CoffeeCupDelete
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
    }
  ]
})
