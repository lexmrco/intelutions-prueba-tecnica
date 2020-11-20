<template>
  <div>
    <b-nav>
      <b-nav-item @click="$router.push({name: 'home'})">Cancelar</b-nav-item>
    </b-nav>
    <PermisoForm :data="item" type="edit" />
  </div>
</template>

<script>
import { Component, Vue, Prop } from 'vue-property-decorator'
import { getModule } from 'vuex-module-decorators'
import PermisoForm from '../components/PermisoForm'

@Component({
  components: { PermisoForm }
})
export default class VerPermiso extends Vue {
  @Prop({ required: true }) item
}
</script>
