<template>
  <div class="card-def px-5 py-5">
    <div class="mb-3">
      <!-- <c-button
        variant-color="green"
        class="rounded-lg flex gap-2 items-center"
        variant="solid"
        @click="addNew()">
        <font-awesome-icon :icon="['fas', 'plus']" class=" cursor-pointer" />Tambah</c-button> -->
    </div>
    <DxDataGrid
      ref="refTableDeliveryItem"
      id="table-default-id"
      :column-auto-width="true"
      :allow-column-reordering="true"
      :show-column-lines="true"
      :show-row-lines="true"
      :show-borders="true"
      :row-alternation-enabled="false"
      :allow-column-resizing="false"
      :word-wrap-enabled="true"
      :data-source="dataSource"
      key-expr="id"
      no-data-text="Tidak Ada Data">
      <DxPaging :page-size="10" :enabled="true" />
      <DxPager
        :visible="true"
        :allowed-page-sizes="[5, 10, 15, 20, 25]"
        display-mode="full"
        :show-page-size-selector="true"
        :show-info="true"
        :show-navigation-buttons="true" />
      <DxColumn
        data-field="nama"
        caption="Nama Kecamatan"
        :visible="true" />
      <DxSearchPanel :visible="true" />
    </DxDataGrid>
    <DxLoadPanel
      :close-on-outside-click="false"
      :visible="loading"
      :position="position"
      :shading="true"
      shading-color="rgba(0,0,0,0.4)" />
  </div>
</template>

<script>
import {
  kecamatanUseCase
} from '~/domain/usecase'

export default {
  name: 'KecamatanPages',
  data() {
    return {
      dataSource: [],
      loading: false,
      position: {
        of: '#table-default-id'
      },
      isShowModal: false,
      dataForm: null
    }
  },
  mounted() {
    this.getAll()
  },
  methods: {
    addNew() {
      this.dataForm = null
      this.isShowModal = true
    },
    closeModal() {
      this.isShowModal = false
    },
    getAll() {
      this.loading = true
      kecamatanUseCase.getAll().then((res) => {
        if (!res.error) {
          this.dataSource = res.result
        }
        this.loading = false
      })
    },
    processDelete(data) {
      kecamatanUseCase.deleteData(data.id).then((res) => {
        console.log('berhasil del', res)
        if (!res.error) {
          this.$toast({
            // title: 'Account created.',
            description: 'Data berhasil dihapus',
            status: 'success',
            duration: 3000
          })
          this.getAll()
        } else {
          this.$toast({
            // title: 'Account created.',
            description: res.message,
            status: 'error',
            duration: 3000
          })
        }
      })
    },
    deleteData(data) {
      this.$swal({
        // title: 'Are you sure?',
        text: `Apakah anda yakin menghapus jenis pengaduan ${data.nama}`,
        icon: 'warning',
        showCancelButton: true,
      }).then((res) => {
        if (res.isConfirmed) {
          this.processDelete(data)
        }
      })
    },
    edit(data) {
      this.isShowModal = true
      this.dataForm = data
    },
    submit(data) {
      kecamatanUseCase.submitData(data.id, {
        nama: data.nama
      }).then((res) => {
        if (!res.error) {
          if (data.id) {
            this.$toast({
              description: 'Data berhasil diubah',
              status: 'success',
              duration: 3000
            })
          } else {
            this.$toast({
              description: 'Data berhasil ditambah',
              status: 'success',
              duration: 3000
            })
          }
          this.getAll()
        } else {
          this.$toast({
            description: res.message,
            status: 'error',
            duration: 3000
          })
        }
      })
    }
  }
}
</script>

<style>

</style>
