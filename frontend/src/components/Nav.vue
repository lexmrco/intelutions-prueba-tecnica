<template>
  <div>
    <b-nav>
      <b-nav-item active>Active</b-nav-item>
      <b-nav-item @click="$router.push({name: 'permisoAdd'})">Agregar permiso</b-nav-item>
      <b-nav-item @click="$router.push({name: 'home'})">Lista</b-nav-item>
      <b-nav-item disabled>Disabled</b-nav-item>
    </b-nav>
  </div>
</template>

<script>
import Vue from 'vue'

export default Vue.extend({
  name: 'Navdefault',
  data () {
    return {
      publicPath: process.env.BASE_URL
    }
  }
})
</script>