/* eslint-disable class-methods-use-this */
import { Response } from '@/domain/entities'
import Repository from '@/data/repository'
import { login } from '~/data/source/remote/api'

class AuthUseCase {
  loginProcess(username: string, password: string): any {
    const data = {
      username,
      password
    }
    return new Repository(login(data), null).getResult(false)
  }
}

const authUseCase = new AuthUseCase()

export {
  authUseCase
}