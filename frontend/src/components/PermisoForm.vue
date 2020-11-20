<template>
  <div>
    <b-card :title="this.cardTitle " >
      <b-form @submit="onSubmit" @reset="onReset">
        <b-form-group
          id="input-group-1"
          label="Nombre empleado:"
          label-for="input-1"
        >
          <b-form-input
            id="input-1"
            v-model="permiso.nombreEmpleado"
            required
            placeholder="Nombre empleado"
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-2" label="Apellido empleado:" label-for="input-2">
          <b-form-input
            id="input-2"
            v-model="permiso.apellidoEmpleado"
            required
            placeholder="Apellidos"
          ></b-form-input>
        </b-form-group> 

        <b-form-group id="input-group-3" label="Tipo de permiso:" label-for="input-3">
          <b-form-select
            id="input-3"
            v-model="permiso.tipoPermisoId"
            :options="tiposPermisos"
            required
          ></b-form-select>
        </b-form-group>

        <b-button type="submit" variant="primary">Guardar</b-button>
        <b-button type="reset" variant="danger">Reset</b-button>
      </b-form>
    </b-card>
  </div>
</template>

<script>
import { Component, Vue, Prop } from 'vue-property-decorator'
import { getModule } from 'vuex-module-decorators'

@Component
export default class PermisoForm extends Vue {
  @Prop({ required: false }) data
  @Prop({ required: true }) type
  
  cardTitle = ''
  alertMessage = ''
  loading = false
  createForm = true
  updateForm = false
  tiposPermisos = [{ value: 1, text: 'Urgencia' }, { value: 2, text: 'Diligencia' }, { value: 3, text: 'Compensatorio' }]
  permiso = { id: null, nombreEmpleado: '', apellidoEmpleado: '', tipoPermisoId: null, tipoPermisoDescripcion: "", fecha: "" }
  
  mounted () {

    if(this.data){
      this.permiso = this.data 
    }
    if(this.type === 'read'){
        this.cardTitle = 'Agregar permiso'
    } else if (this.type === 'read') {
      this.cardTitle = 'Detalle permiso'
    } else {
      this.cardTitle = 'Editar permiso'
    }

    this.loading = false
  }

  onSubmit() {

  }

  onReset(){

  }
}
</script>
