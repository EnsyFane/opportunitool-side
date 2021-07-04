import { TestBed } from '@angular/core/testing';

import { OpportunityService } from './opportunity.service';

describe('OpportunityService', () => {
    let service: OpportunityService;
    let mockHttp;

    beforeEach(() => {
        mockHttp = jasmine.createSpyObj('http', ['get', 'post']);
        service = new OpportunityService(mockHttp);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
