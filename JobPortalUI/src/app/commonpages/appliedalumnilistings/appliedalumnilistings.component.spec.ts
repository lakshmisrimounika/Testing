import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppliedalumnilistingsComponent } from './appliedalumnilistings.component';

describe('AppliedalumnilistingsComponent', () => {
  let component: AppliedalumnilistingsComponent;
  let fixture: ComponentFixture<AppliedalumnilistingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppliedalumnilistingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppliedalumnilistingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
