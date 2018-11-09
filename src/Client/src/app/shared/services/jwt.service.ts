import { Injectable } from '@angular/core';

@Injectable()
export class JWTService {
    private JWTTokenKey = 'jwtToken';

    getToken(): String {
        return window.localStorage.getItem(this.JWTTokenKey);
    }

    setToke(token: string): void {
        window.localStorage.setItem(this.JWTTokenKey, token);
    }

    destroyToken(): void {
        window.localStorage.removeItem(this.JWTTokenKey);
    }
}

