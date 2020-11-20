import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../pages/Home.vue'
import PermisoAdd from '../pages/PermisoAdd'
import PermisoEdit from '../pages/PermisoEdit'
import PermisoDetails from '../pages/PermisoDetails'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/ver',
    name: 'permisoDetails',
    component: PermisoDetails,
    props: true
  },{
    path: '/agregar',
    name: 'permisoAdd',
    component: PermisoAdd,
  },{
    path: '/editar',
    name: 'permisoEdit',
    component: PermisoEdit,
    props: true
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
