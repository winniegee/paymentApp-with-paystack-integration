import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VerifyAccountNumberComponent } from './verify-account-number.component';

describe('VerifyAccountNumberComponent', () => {
  let component: VerifyAccountNumberComponent;
  let fixture: ComponentFixture<VerifyAccountNumberComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VerifyAccountNumberComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VerifyAccountNumberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
