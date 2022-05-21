import { Remote, remoteEnum } from '@/data/source/remote/remote'

const baseUrl = 'Supplier'

const fetchAllSupplier = (filter = '') => new Remote(remoteEnum.get, `${baseUrl}${filter}`)
const fetchOneSupplier = (id: number) => new Remote(remoteEnum.get, `${baseUrl}/${id}`)
const addSupplier = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)
const editSupplier = (id: any, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}`, data)
const deleteSupplier = (id: any) => new Remote(remoteEnum.delete, `${baseUrl}/${id}`)
const changeIsActiveSupplier = (id: any, data: any) => new Remote(remoteEnum.patch, `${baseUrl}/${id}/isActive`, data)

export {
  fetchAllSupplier,
  fetchOneSupplier,
  addSupplier,
  editSupplier,
  deleteSupplier,
  changeIsActiveSupplier
}
