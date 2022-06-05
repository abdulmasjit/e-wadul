import { Response } from '@/domain/entities'
import Repository from '@/data/repository'
import ICrud from '@/domain/usecase/iCrud'
import {
  fetchPengaduan, fetchOnePengaduan, addPengaduan, editPengaduan, deletePengaduan
} from '@/data/source/remote/api'

class PengaduanUseCase implements ICrud {
  getAll(filter: any = ''): Promise<Response> {
    const params = filter
    return new Repository(fetchPengaduan(params), null).getResult(false)
  }

  async getDataForm(id: any = null): Promise<any> {
    if (id) {
      const response = await new Repository(fetchOnePengaduan(id), null).getResult(false)
      return {
        title: 'Edit Pengaduan',
        data: response
      }
    }

    return {
      title: 'Tambah Pengaduan',
      data: null
    }
  }

  submitData(id: any, data: any): Promise<Response> {
    if (id) {
      return new Repository(editPengaduan(id, data), null).getResult(false)
    }
    return new Repository(addPengaduan(data), null).getResult(false)
  }

  deleteData(id: any): Promise<Response> {
    return new Repository(deletePengaduan(id), null).getResult(false)
  }
}

const pengaduanUseCase = new PengaduanUseCase()

export {
  pengaduanUseCase
}