<template>
  <div>
    <b-table striped hover :items="items" :fields="fields">
      <template #cell(actions)="row">
        <b-button size="sm" @click="$router.push({name: 'permisoDetails', params: { item: row.item }})" class="mr-1">
          Ver
        </b-button>
        <b-button size="sm" @click="confirmRemove(row.item)">
          Eliminar
        </b-button>
      </template>
    </b-table>
    <b-modal 
      :id="infoModal.id"
      v-model="modalShow"
      :title="infoModal.title" 
      @hide="resetInfoModal"
      @ok="remove(infoModal.rowId)">
      {{ infoModal.content }}
    </b-modal>
  </div>
</template>

<script>
import { Component, Vue, Prop } from 'vue-property-decorator'
import { getModule } from 'vuex-module-decorators'

@Component
export default class Home extends Vue {
  
  alertMessage = ''
  loading = false
  totalClientes = 0
  modalShow = false
  infoModal = {
    id: 'info-modal',
    title: 'Eliminar',
    content: '',
    rowId: 0
  }
  items = [
          { id: 1, nombreEmpleado: 'Dickerson', apellidoEmpleado: 'Macdonald', tipoPermisoId: 1, tipoPermisoDescripcion: "Urgencia", fecha: "11/11/2020" },
          { id: 2, nombreEmpleado: 'Larsen', apellidoEmpleado: 'Shaw', tipoPermisoId: 2, tipoPermisoDescripcion: "Cita médica", fecha: "11/11/2020" },
          { id: 3, nombreEmpleado: 'Geneva', apellidoEmpleado: 'Wilson', tipoPermisoId: 3, tipoPermisoDescripcion: "Compensatorio", fecha: "11/11/2020" },
          { id: 4, nombreEmpleado: 'Jami', apellidoEmpleado: 'Carney', tipoPermisoId: 2, tipoPermisoDescripcion: "Cita médica", fecha: "11/11/2020" }
        ]
  fields = [
    { key: 'nombreEmpleado', label: 'Nombre', sortable: true, sortDirection: 'desc', class: 'text-center' },
    { key: 'apellidoEmpleado', label: 'Apellidos', sortable: true },
    { key: 'tipoPermiso', label: 'Tipo permiso', sortable: true },
    { key: 'fecha', label: 'Fecha', sortable: true },
    { key: 'actions', label: 'Acciones' }
  ]

  mounted () {
    this.loading = false
  }

  confirmRemove(item) {
    this.modalShow = !this.modalShow
    this.infoModal.rowId = item.id
    this.infoModal.content = `Está seguro que desea eliminar el registro: Empleado '${item.nombreEmpleado} ${item.apellidoEmpleado}'?`
  }

  remove(id){
    console.log(id)
  }
  resetInfoModal() {
    this.infoModal.content = ''
    this.infoModal.rowId = 0
  }
}
</script>
