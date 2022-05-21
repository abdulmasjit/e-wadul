import { Remote, remoteEnum } from '@/data/source/remote/remote'

const baseUrl = 'Service'

const fetchAllService = (filter = '') => new Remote(remoteEnum.get, `${baseUrl}${filter}`)
const fetchOneService = (id: number) => new Remote(remoteEnum.get, `${baseUrl}/${id}`)
const addService = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)
const editService = (id: any, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}`, data)
const deleteService = (id: any) => new Remote(remoteEnum.delete, `${baseUrl}/${id}`)
const changeIsActiveService = (id: number, data: any) => new Remote(remoteEnum.put, `${baseUrl}/${id}/isActive`, data)

export {
  fetchAllService,
  fetchOneService,
  addService,
  editService,
  deleteService,
  changeIsActiveService
}
