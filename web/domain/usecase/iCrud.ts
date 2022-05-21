import { Response } from '@/domain/entities'

export default interface ICrud {
  getAll(filter: any): Promise<Response>
  getDataForm(id: any): Promise<any>
  submitData(id: any, data: any): Promise<Response>
  deleteData(id: any): Promise<Response>
  changeIsActive(id: any, data: any): Promise<Response>
}
