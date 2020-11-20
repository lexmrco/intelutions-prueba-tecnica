<template>
  <div>
    <b-nav>
      <b-nav-item @click="$router.push({name: 'home'})">Volver</b-nav-item>
      <b-nav-item @click="$router.push({name: 'permisoAdd'})">Agregar permiso</b-nav-item>
    </b-nav>
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
