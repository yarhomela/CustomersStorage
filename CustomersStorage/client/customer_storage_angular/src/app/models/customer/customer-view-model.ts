export class CustomerViewModel {
    customerId: number;
    name: string;
    companyName: string;
    phone: string;
    email: string;

    constructor(customerId: number, name: string, companyName: string, phone: string, email: string) {

        this.customerId = customerId,
        this.name = name,
        this.companyName = companyName,
        this.phone = phone,
        this.email = email
    }
}