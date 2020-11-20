<template>
  <div id="app">
    <NavDefault></NavDefault>
    <b-container>
      <router-view></router-view>
    </b-container>
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

