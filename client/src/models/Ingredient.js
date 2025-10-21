export class Ingredient {
    constructor(data) {
        this.id = data.id || data._id
        this.createdAt = data.createdAt ? new Date(data.createdAt) : null
        this.updatedAt = data.updatedAt ? new Date(data.updatedAt) : null
        this.name = data.name
        this.quantity = data.quantity
    }
}