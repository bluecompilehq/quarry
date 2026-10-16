import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityRail } from './activity-rail';

describe('ActivityRail', () => {
  let component: ActivityRail;
  let fixture: ComponentFixture<ActivityRail>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ActivityRail],
    }).compileComponents();

    fixture = TestBed.createComponent(ActivityRail);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
