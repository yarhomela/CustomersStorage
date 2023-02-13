export class CreateCustomerViewModel {
    name: string;
    companyName: string;
    phone: string;
    email: string;

    constructor(name: string, companyName: string, phone: string, email: string) {
        this.name = name,
        this.companyName = companyName,
        this.phone = phone,
        this.email = email
    }
}