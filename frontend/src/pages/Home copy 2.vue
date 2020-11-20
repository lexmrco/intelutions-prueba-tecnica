<template>
  <h3>Hola mundo</h3>
</template>

<script>
import { Component, Vue, Prop } from 'vue-property-decorator'
import { getModule } from 'vuex-module-decorators'

@Component
export default class Home extends Vue {
  
  alertMessage = ''
  loading = false
  totalClientes = 0

  mounted () {
    this.loading = false
  }
}
</script>
