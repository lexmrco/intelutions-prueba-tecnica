<template>
  <div id="app">
    <NavDefault></NavDefault>
    <router-view></router-view>
  </div>
</template>

<script>

import Vue from 'vue'
import NavDefault from './components/Nav.vue'

export default Vue.extend({
  name: 'App',
  components:{NavDefault},
  props: {
    source: String
  },
  data: () => ({
    drawer: null
  }),
  created () {
    // this.$vuetify.theme.dark = true
  }
})
</script>

