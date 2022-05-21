import { Remote, remoteEnum } from '@/data/source/remote/remote'

const baseUrl = 'login'

const login = (data: any) => new Remote(remoteEnum.post, `${baseUrl}`, data)

export {
  login
}
