<template>
  <div>
    <div class="mb-3">
      <c-button
        variant-color="green"
        class="rounded-lg flex gap-2 items-center"
        variant="solid"
        @click="addNew()">
        <font-awesome-icon :icon="['fas', 'plus']" class=" cursor-pointer" />Tambah</c-button>
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
        caption="Nama Jenis Pengaduan"
        :visible="true" />
      <DxColumn
        caption="Action"
        :visible="true"
        :min-width="100"
        cell-template="actionTemplate"
        alignment="left" />
      <template #actionTemplate="{ data }">
        <div class="flex gap-4">
          <font-awesome-icon
            :icon="['fas', 'pen-to-square']"
            class=" text-green-500 text-lg cursor-pointer"
            @click="edit(data.data)" />
          <font-awesome-icon
            :icon="['fas', 'trash-can']"
            class=" text-red-500 text-lg cursor-pointer"
            @click="deleteData(data.data)" />
          <!-- {{data.data.StatusPengirimanId}} -->
          <!-- <i class="pi pi-ellipsis-h text-base cursor-pointer text-black" aria:haspopup="true" aria-controls="overlay_panel"></i> -->
        </div>
      </template>
      <DxSearchPanel :visible="true" />
    </DxDataGrid>
    <DxLoadPanel
      :close-on-outside-click="false"
      :visible="loading"
      :position="position"
      :shading="true"
      shading-color="rgba(0,0,0,0.4)" />
    <FormJenisPengaduan
      :isShow="isShowModal"
      @closeModal="closeModal"
      :data="dataForm"
      @submitData="submit"
      v-if="isShowModal" />
  </div>
</template>

<script>
import {
  jenisPengaduanUseCase
} from '~/domain/usecase'
import FormJenisPengaduan from '~/views/jenis-pengaduan/FormJenisPengaduan.vue'

export default {
  name: 'JenisPengaduanPages',
  components: {
    FormJenisPengaduan
  },
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
      jenisPengaduanUseCase.getAll().then((res) => {
        if (!res.error) {
          this.dataSource = res.result
        }
        this.loading = false
      })
    },
    processDelete(data) {
      jenisPengaduanUseCase.deleteData(data.id).then((res) => {
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
      console.log('data submit', data)
      jenisPengaduanUseCase.submitData(data.id, {
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
