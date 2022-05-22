import { Response } from '@/domain/entities'
import Repository from '@/data/repository'
import ICrud from '@/domain/usecase/iCrud'
import {
  fetchJenisPengaduan, fetchOneJenisPengaduan, addJenisPengaduan, editJenisPengaduan, deleteJenisPengaduan
} from '@/data/source/remote/api'

class JenisPengaduanUseCase implements ICrud {
  getAll(filter: any = ''): Promise<Response> {
    const params = filter
    return new Repository(fetchJenisPengaduan(params), null).getResult(false)
  }

  async getDataForm(id: any): Promise<any> {
    if (id !== '') {
      const response = await new Repository(fetchOneJenisPengaduan(id), null).getResult(false)
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
      return new Repository(editJenisPengaduan(id, data), null).getResult(false)
    }
    return new Repository(addJenisPengaduan(data), null).getResult(false)
  }

  deleteData(id: any): Promise<Response> {
    return new Repository(deleteJenisPengaduan(id), null).getResult(false)
  }
}

const jenisPengaduanUseCase = new JenisPengaduanUseCase()

export {
  jenisPengaduanUseCase
}