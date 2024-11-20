export interface User{   //this is used to discribe the shape os User
    username: string;
    knownAs: string;
    gender: string;
    token: string;
    photoUrl?: string;
    roles: string[];
}

