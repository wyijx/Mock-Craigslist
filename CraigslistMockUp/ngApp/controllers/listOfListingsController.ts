namespace CraigslistMockUp.Controllers {
    export class ListOfListingsController {
        public listings;

        constructor(private $http) {
            $http.get('/api/listings')
                .then((response) => {
                    this.listings = response.data;
                });
        }
    }
}