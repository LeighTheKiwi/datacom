export type Error = {
    type: string;
    title: string;
    status: number;
    errors: {[name: string]: string[]}
}