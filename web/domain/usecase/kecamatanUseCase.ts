import { Response } from '@/domain/entities'
import Repository from '@/data/repository'
import ICrud from '@/domain/usecase/iCrud'
import {
  fetchKecamatan, fetchOneKecamatan, addKecamatan, editKecamatan, deleteKecamatan
} from '@/data/source/remote/api'

class KecamatanUseCase implements ICrud {
  getAll(filter: any = ''): Promise<Response> {
    const params = filter
    return new Repository(fetchKecamatan(params), null).getResult(false)
  }

  async getDataForm(id: any): Promise<any> {
    if (id !== '') {
      const response = await new Repository(fetchOneKecamatan(id), null).getResult(false)
      return {
        title: 'Edit Stiker',
        data: response
      }
    }

    return {
      title: 'Tambah Stiker',
      data: null
    }
  }

  submitData(id: any, data: any): Promise<Response> {
    if (id) {
      return new Repository(editKecamatan(id, data), null).getResult(false)
    }
    return new Repository(addKecamatan(data), null).getResult(false)
  }

  deleteData(id: any): Promise<Response> {
    return new Repository(deleteKecamatan(id), null).getResult(false)
  }
}

const kecamatanUseCase = new KecamatanUseCase()

export {
  kecamatanUseCase
}