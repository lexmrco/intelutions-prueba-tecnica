<template>
  <div>
    <PermisoForm :data="item" type="read" />
  </div>
</template>

<script>
import { Component, Vue, Prop } from 'vue-property-decorator'
import { getModule } from 'vuex-module-decorators'
import PermisoForm from '../components/PermisoForm'

@Component({
  components: { PermisoForm }
})
export default class PermisoDetails extends Vue {
  @Prop({ required: true }) item
}
</script>
