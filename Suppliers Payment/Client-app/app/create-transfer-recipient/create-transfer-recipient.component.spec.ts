import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateTransferRecipientComponent } from './create-transfer-recipient.component';

describe('CreateTransferRecipientComponent', () => {
  let component: CreateTransferRecipientComponent;
  let fixture: ComponentFixture<CreateTransferRecipientComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateTransferRecipientComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateTransferRecipientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
