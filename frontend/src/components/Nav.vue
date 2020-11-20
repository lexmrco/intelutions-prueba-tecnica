<template>
  <div>
      <b-navbar toggleable="lg" type="dark" variant="info">
    <b-navbar-brand href="#">Prueba técnica</b-navbar-brand>

    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    
  </b-navbar>
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