export interface RegisterCredentials {
  email: string;
  password: string;
  verifyPassword: string;
  firstName: string;
  lastName: string;
  address: Address;
}

export interface Address {
  country: string;
  city: string;
  streetAddress: string;
  postCode: string;
}
