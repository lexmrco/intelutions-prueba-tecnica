<template>
  <div>
    <PermisoForm type="add" />
  </div>
</template>

<script>
import { Component, Vue, Prop } from 'vue-property-decorator'
import { getModule } from 'vuex-module-decorators'
import PermisoForm from '../components/PermisoForm'

@Component({
  components: { PermisoForm }
})
export default class PermisoAdd extends Vue {

}
</script>
