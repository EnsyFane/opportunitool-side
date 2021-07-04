import { OpportunityService } from './opportunity.service';

describe('OpportunityService', () => {
    let service: OpportunityService;
    let mockHttp;
    let snackbar;

    beforeEach(() => {
        mockHttp = jasmine.createSpyObj('http', ['get', 'post']);
        snackbar = jasmine.createSpyObj('snackbar', ['open']);
        service = new OpportunityService(mockHttp, snackbar);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
