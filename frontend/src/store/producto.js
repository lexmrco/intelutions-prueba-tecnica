import { Action, Module, Mutation, VuexModule } from 'vuex-module-decorators'

@Module({
  name: 'producto',
  namespaced: true
})

export  class ProductoStore extends VuexModule {
  items = []

  get totalItems () {
    return this.items.length
  }

  @Mutation
  setDefaultvalues () {
    this.items = [
      {
        id: 1,
        nombre: 'Itaú',
        nit: '34567210',
        correoElectronico: 'servicio@itau.com'
      },
      {
        id: 2,
        nombre: 'Bradesco',
        nit: '23412775',
        correoElectronico: 'servicio@bradesco.com'
      },
      {
        id: 3,
        nombre: 'Vale',
        nit: '33455790',
        correoElectronico: 'servicio@vale.com'
      },
      {
        id: 4,
        nombre: 'Ecopetrol',
        nit: '23228133',
        correoElectronico: 'servicio@ecopetrol.com'
      },
      {
        id: 5,
        nombre: 'América Móvil',
        nit: '80590444',
        correoElectronico: 'servicio@amovil.com'
      },
      {
        id: 6,
        nombre: 'Bel corp',
        nit: '32900111',
        correoElectronico: 'servicio@belcorp.com'
      },
      {
        id: 7,
        nombre: 'Natura',
        nit: '67221889',
        correoElectronico: 'servicio@natura.com'
      },
      {
        id: 8,
        nombre: 'DHL',
        nit: '19002334',
        correoElectronico: 'servicio@dhl.com'
      },
      {
        id: 9,
        nombre: 'Ramo',
        nit: '20190673',
        correoElectronico: 'servicio@ramo.com'
      },
      {
        id: 10,
        nombre: 'Nutresa',
        nit: '41441123',
        correoElectronico: 'servicio@nutresa.com'
      }]
  }
}
